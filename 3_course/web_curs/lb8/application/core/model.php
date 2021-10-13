<?php

class Model
{
	protected $_sql;
	private $servername = "localhost";
	private $database = "gallery";
	private $username = "Andrey";
	private $password = "2012";

	function open_connect()
	{
		// Создаем соединение
		$this->_sql = mysqli_connect($this->servername, $this->username, $this->password, $this->database);
		// Проверяем соединение
		if (!$this->_sql) {
			die("Connection failed: " . mysqli_connect_error());
			return false;
		}
		return true;
	}

	function clouse_connect()
	{
		if(isset($this->_sql))
		{
			mysqli_close($this->_sql);
		}
	}
}
?>