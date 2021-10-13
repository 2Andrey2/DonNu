<?php
class View
{	
	function generate($content_view, $template_view, $results = null)
	{
		?>
		<link rel="stylesheet" href="../application/css/<?php echo($content_view.".css"); ?>">
		<link rel="stylesheet" href="../application/css/style.css">
		<link rel="stylesheet" href="../application/css/mainmenu.css">
		<script src="../jquery-3.6.0.min.js"></script>
		<?php
		include 'application/views/'.$template_view.".php";
	}
}
?>