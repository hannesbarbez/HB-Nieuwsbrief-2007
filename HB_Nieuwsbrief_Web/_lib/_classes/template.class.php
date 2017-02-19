<?php

  class Template {
    var $classname = "Template";
    var $root     = ".";
    var $file     = array();
    var $varkeys  = array();
    var $varvals  = array();
    var $unknowns = "remove";
    var $halt_on_error  = "yes";
    var $last_error     = "";

    function Template($root = ".", $unknowns = "remove") {
      $this->set_root($root);
      $this->set_unknowns($unknowns);
    }

    function set_root($root) {
      if (!is_dir($root)) {
        $this->halt("set_root: $root is not a directory.");
        return false;
      }
      $this->root = $root;
      return true;
    }

    function set_unknowns($unknowns = "remove") {
      $this->unknowns = $unknowns;
    }

    function set_file($varname, $filename = "") {
      if (!is_array($varname)) {
        if ($filename == "") {
          $this->halt("set_file: For varname $varname filename is empty.");
          return false;
        }
        $this->file[$varname] = $this->filename($filename);
      } else {
        reset($varname);
        while(list($v, $f) = each($varname)) {
          if ($f == "") {
            $this->halt("set_file: For varname $v filename is empty.");
            return false;
          }
          $this->file[$v] = $this->filename($f);
        }
      }
      return true;
    }

    function set_block($parent, $varname, $name = "") {
      if (!$this->loadfile($parent)) {
        $this->halt("set_block: unable to load $parent.");
        return false;
      }
      if ($name == "") {
        $name = $varname;
      }

      $str = $this->get_var($parent);
      $reg = "/[ \t]*<!--\s+BEGIN $varname\s+-->\s*?\n?(\s*.*?\n?)\s*<!--\s+END $varname\s+-->\s*?\n?/sm";
      preg_match_all($reg, $str, $m);
      $str = preg_replace($reg, "{" . "$name}", $str);
      $this->set_var($varname, $m[1][0]);
      $this->set_var($parent, $str);
      return true;
    }

    function set_var($varname, $value = "", $append = false) {
      if (!is_array($varname)) {
        if (!empty($varname)) {
          $this->varkeys[$varname] = "/".$this->varname($varname)."/";
          if ($append && isset($this->varvals[$varname])) {
            $this->varvals[$varname] .= $value;
          } else {
            $this->varvals[$varname] = $value;
          }
        }
      } else {
        reset($varname);
        while(list($k, $v) = each($varname)) {
          if (!empty($k)) {
            $this->varkeys[$k] = "/".$this->varname($k)."/";
            if ($append && isset($this->varvals[$k])) {
              $this->varvals[$k] .= $v;
            } else {
              $this->varvals[$k] = $v;
            }
          }
        }
      }
    }

    function clear_var($varname) {
      if (!is_array($varname)) {
        if (!empty($varname)) {
          $this->set_var($varname, "");
        }
      } else {
        reset($varname);
        while(list($k, $v) = each($varname)) {
          if (!empty($v)) {
            $this->set_var($v, "");
          }
        }
      }
    }

    function unset_var($varname) {
      if (!is_array($varname)) {
        if (!empty($varname)) {
          unset($this->varkeys[$varname]);
          unset($this->varvals[$varname]);
        }
      } else {
        reset($varname);
        while(list($k, $v) = each($varname)) {
          if (!empty($v)) {
            unset($this->varkeys[$v]);
            unset($this->varvals[$v]);
          }
        }
      }
    }

    function subst($varname) {
      $varvals_quoted = array();
      if (!$this->loadfile($varname)) {
        $this->halt("subst: unable to load $varname.");
        return false;
      }

      // quote the replacement strings to prevent bogus stripping of special chars
      reset($this->varvals);
      while(list($k, $v) = each($this->varvals)) {
        $varvals_quoted[$k] = preg_replace(array('/\\\\/', '/\$/'), array('\\\\\\\\', '\\\\$'), $v);
      }

      $str = $this->get_var($varname);
      $str = preg_replace($this->varkeys, $varvals_quoted, $str);
      return $str;
    }

    function psubst($varname) {
      print $this->subst($varname);
      return false;
    }

    function parse($target, $varname, $append = false) {
      if (!is_array($varname)) {
        $str = $this->subst($varname);
        if ($append) {
          $this->set_var($target, $this->get_var($target) . $str);
        } else {
          $this->set_var($target, $str);
        }
      } else {
        reset($varname);
        while(list($i, $v) = each($varname)) {
          $str = $this->subst($v);
          if ($append) {
            $this->set_var($target, $this->get_var($target) . $str);
          } else {
            $this->set_var($target, $str);
          }
        }
      }
      return $str;
    }

    function pparse($target, $varname, $append = false) {
      print $this->finish($this->parse($target, $varname, $append));
      return false;
    }

    function get_vars() {
      reset($this->varkeys);
      while(list($k, $v) = each($this->varkeys)) {
        $result[$k] = $this->get_var($k);
      }
      return $result;
    }

    function get_var($varname) {
      if (!is_array($varname)) {
        if (isset($this->varvals[$varname])) {
          $str = $this->varvals[$varname];
        } else {
          $str = "";
        }
        return $str;
      } else {
        reset($varname);
        while(list($k, $v) = each($varname)) {
          if (isset($this->varvals[$v])) {
            $str = $this->varvals[$v];
          } else {
            $str = "";
          }
          $result[$v] = $str;
        }
        return $result;
      }
    }

    function get_undefined($varname) {
      if (!$this->loadfile($varname)) {
        $this->halt("get_undefined: unable to load $varname.");
        return false;
      }

      preg_match_all("/{([^ \t\r\n}]+)}/", $this->get_var($varname), $m);
      $m = $m[1];
      if (!is_array($m)) {
        return false;
      }

      reset($m);
      while(list($k, $v) = each($m)) {
        if (!isset($this->varkeys[$v])) {
          $result[$v] = $v;
        }
      }

      if (count($result)) {
        return $result;
      } else {
        return false;
      }
    }

    function finish($str) {
      switch ($this->unknowns) {
        case "keep":
        break;

        case "remove":
          $str = preg_replace('/{[^ \t\r\n}]+}/', "", $str);
        break;

        case "comment":
          $str = preg_replace('/{([^ \t\r\n}]+)}/', "<!-- Template variable \\1 undefined -->", $str);
        break;
      }

      return $str;
    }

    function p($varname) {
      print $this->finish($this->get_var($varname));
    }

    function get($varname) {
      return $this->finish($this->get_var($varname));
    }

    function filename($filename) {
      if (substr($filename, 0, 1) != "/") {
        $filename = $this->root."/".$filename;
      }

      if (!file_exists($filename)) {
        $this->halt("filename: file $filename does not exist.");
      }
      return $filename;
    }

    function varname($varname) {
      return preg_quote("{".$varname."}");
    }

    function loadfile($varname) {
      if (!isset($this->file[$varname])) {
        // $varname does not reference a file so return
        return true;
      }

      if (isset($this->varvals[$varname])) {
        // will only be unset if varname was created with set_file and has never been loaded
        // $varname has already been loaded so return
        return true;
      }
      $filename = $this->file[$varname];

      /* use @file here to avoid leaking filesystem information if there is an error */
      $str = implode("", @file($filename));
      if (empty($str)) {
        $this->halt("loadfile: While loading $varname, $filename does not exist or is empty.");
        return false;
      }

      $this->set_var($varname, $str);

      return true;
    }

    function halt($msg) {
      $this->last_error = $msg;

      if ($this->halt_on_error != "no") {
        $this->haltmsg($msg);
      }

      if ($this->halt_on_error == "yes") {
        die("<b>Halted.</b>");
      }

      return false;
    }

    function haltmsg($msg) {
      printf("<b>Template Error:</b> %s<br>\n", $msg);
    }

  }

?>
