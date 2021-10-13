<!DOCTYPE html>
<html>
<head>
    <title>Главная</title>
</head>
<body>
    <div class="menu">
        <ul>
            <li><a href="/">Главная</a></li>
            <li><a href="/Download">Загрузить изображение</a></li>
        </ul>
    </div>
    <div>
        <?php include 'application/views/'.$content_view.".php"; ?>
    </div>
</body>
</html>