<html>
<head>
    <title>Связь с разработчиком</title>
    <link rel="stylesheet" href="css/css.css">
    <link rel="stylesheet" href="css/contact_developer.css">
</head>
<body>
    <header>
        <?php include 'loga_menu.php'; ?>
    </header>
    <mein>
    <div>
        <div class="logo_page">
            <h1>Связь с разработчиком</h1>
        <div>
    <div>
    <form action="" class="air">
        <div class="form-inner">
            <div class="stripes-block"></div>
            <div class="form-row">
                <label for="name">Имя</label>
                <input type="text" id="name" required>
            </div>
            <div class="form-row">
                <label for="address">Адрес</label>
                <textarea rows="3" id="address" required></textarea>
            </div>
            <div class="form-row-icon">
                <i class="fa fa-tty"></i>
                <input type="text" id="phone" required>
            </div>
            <div class="form-row-icon">
                <i class="fa fa-envelope-o"></i>
                <input type="email" id="email" required>
            </div>
            <div class="form-row-icon">
                <i class="fa fa-paper-plane-o"></i>
                <input type="submit" value="">
            </div>
        </div>
    </form>
    </mein>
    <footer>
        <?php include 'futer.php'; ?>
    </footer>
</body>
</html>