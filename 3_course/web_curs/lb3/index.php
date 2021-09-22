<html>
<head>
    <title>Главная</title>
    <link rel="stylesheet" href="css.css">
</head>
<body>
    <header>
        <?php include 'header.php'; ?>
    </header>
    <?php
    if($_GET['task'] == "1") { include 'task/task1.php'; }
    if($_GET['task'] == "2") { include 'task/task2.php'; }
    if($_GET['task'] == "3") { include 'task/task3.php'; }
    if($_GET['task'] == "4") { include 'task/task4.php'; }
    ?>
</body>
</html>


