<?php

class Controller_Main extends Controller
{
	function __construct()
	{
		parent::__construct();
		$this->model = new Model_Main();
    }

	function action_index()
	{
		$this->model->open_connect();
		$this->model->update_images();
		if($images = $this->model->upload_images())
		{
			$this->view->generate('main_view', 'template_view',$images);
		}
		$this->model->clouse_connect();
	}

	function action_full()
	{
		$this->model->open_connect();
		if(isset($_GET['img']))
		{
			if($images = $this->model->upload_image($_GET['img']))
			{
				$this->view->generate('main_view_full', 'template_view',$images);
			}
		}
		$this->model->clouse_connect();
	}
}
?>