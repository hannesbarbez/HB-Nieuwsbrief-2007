{HEADER}
<div id="darkcontent">
	<div id="darkercontent">
		<h2>{HEADERCONTENT}</h2>
		<p>
		{CONTENT}
		</p>
		<form action="{ACTION}" method="post">
			<input type="hidden" name="postback" value="" />	
			<label for="mail">E-mailadres:</label>
			<div class="error" id="msgMail">{MSGMAIL}</div>
			<input name="mail" id="mail" maxlength="60" size="33" type="text" value="{MAIL}" />			
			<input type="submit" name="btnOk" id="btnOk" value="OK" />
		</form>
	</div>
</div>
{FOOTER}