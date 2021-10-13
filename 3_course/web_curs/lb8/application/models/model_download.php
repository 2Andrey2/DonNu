<?php
class Model_Download extends Model
{
    var $nameimg,
    $dest_path,
    $fileExtension;


    function updateFile()
    {
        $update = $this->_sql->query("SELECT * FROM `users` WHERE `name`='".$_POST['nameUser']."'");
        if(!$update->num_rows)
        {
            $this->_sql->query("INSERT INTO `users` (`name`,`email`) VALUES ('".$_POST['nameUser']."','".$_POST['emailUser']."')");
        }
        $update = $this->_sql->query("SELECT `id` FROM `users` WHERE `name`='".$_POST['nameUser']."'");
        $update = $update->fetch_row();
        $this->_sql->query("INSERT INTO `img` (`Name`,`path`,`extension`,`user`,`information`) VALUES ('".$this->nameimg."','".$this->dest_path."','".$this->fileExtension."',".$update[0].",'".$_POST['info']."')");
    }

    function Download()
    {
        session_start();

        $message = ''; 
        if (isset($_POST['uploadBtn']) && $_POST['uploadBtn'] == 'Загрузить')
        {
        if (isset($_FILES['uploadedFile']) && $_FILES['uploadedFile']['error'] === UPLOAD_ERR_OK)
        {
            // get details of the uploaded file
            $fileTmpPath = $_FILES['uploadedFile']['tmp_name'];
            $fileName = $_FILES['uploadedFile']['name'];
            $fileSize = $_FILES['uploadedFile']['size'];
            $fileType = $_FILES['uploadedFile']['type'];
            $fileNameCmps = explode(".", $fileName);
            $this->fileExtension = strtolower(end($fileNameCmps));

            // sanitize file-name
            $newFileName = $fileNameCmps[0] . "." . $this->fileExtension;
            $this->nameimg = $fileNameCmps[0];

            // check if file has one of the following extensions
            $allowedfileExtensions = array('jpg');

            if (in_array($this->fileExtension, $allowedfileExtensions))
            {
            // directory in which the uploaded file will be moved
            $uploadFileDir = './img/';
            $this->dest_path = $uploadFileDir . $newFileName;

            if(move_uploaded_file($fileTmpPath, $this->dest_path)) 
            {
                $message ='Файл успешно загружен.';
                $this->updateFile();
            }
            else 
            {
                $message = 'Произошла ошибка при перемещении файла в каталог для загрузки. Убедитесь, что каталог загрузки доступен для записи веб-сервером.';
            }
            }
            else
            {
            $message = 'Загрузка не удалась. Допустимые типы файлов:' . implode(',', $allowedfileExtensions);
            }
        }
        else
        {
            $message = 'Ошибка при загрузке файла. Пожалуйста, проверьте следующую ошибку.<br>';
            $message .= 'Ошибка:' . $_FILES['uploadedFile']['error'];
        }
        }
        return $message;
    }
}
?>