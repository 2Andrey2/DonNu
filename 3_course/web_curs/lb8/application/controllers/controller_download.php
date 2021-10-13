<?php

class Controller_Download extends Controller
{
	function __construct()
	{
		parent::__construct();
		$this->model = new Model_Download();
    }

	function action_index()
	{
		$this->view->generate('download_view', 'template_view');
	}
	function action_downloadFile()
	{
		$this->model->open_connect();
		$this->view->generate('download_view', 'template_view',$this->model->Download());
		$this->model->clouse_connect();
	}
}
?>