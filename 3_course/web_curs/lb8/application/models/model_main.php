<?php
class Model_Main extends Model
{
    function upload_images ()
    {
        if($image = $this->_sql->query("SELECT * FROM `img`"))
        {
            return $image;
        }
    }

    function update_images ()
    {
        $folder = "img";
        $files = scandir($folder);

        foreach ($files as $file)
        {
            $extension = explode( '.', $file);
            if($extension[1] == "jpg")
            {
                $check = $this->_sql->query("SELECT * FROM `img` WHERE `Name`= '".$extension[0]."'");
                $check = $check->fetch_assoc();
                if(!isset($check))
                {
                    $this->_sql->query("INSERT INTO `img` (`Name`,`path`,`extension`) VALUES ('".$extension[0]."','img/".$file."','".$extension[1]."')");
                }
            }
        }
        $files = $this->_sql->query("SELECT * FROM `img`");
        while ($row = $files->fetch_assoc()) {
            if(!file_exists($row['path']))
            {
                $this->_sql->query("DELETE FROM `img` WHERE id=".$row['id']);
            }
        }
    }

    function upload_image ($id)
    {
        $image = $this->_sql->query("SELECT * FROM `img` JOIN `users` ON `img`.`user`=`users`.`id` WHERE `img`.`id`=".$id);
        if($image->num_rows != 0)
        {
            $this->_sql->query("UPDATE `img` SET views = views+1 WHERE `id`=".$id);
            return $image;
        }
        else
        {
            $image = $this->_sql->query("SELECT * FROM `img` WHERE `id`=".$id);
            $this->_sql->query("UPDATE `img` SET views = views+1 WHERE `id`=".$id);
            return $image;
        }
    }
}
?>