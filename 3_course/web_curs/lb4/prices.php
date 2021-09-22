<!doctype html>
<html lang="ru">
    <link rel="stylesheet" type="text/css" href="css/main.css">
    <link rel="stylesheet" type="text/css" href="css/prices.css">

    <div class="burger">
        <span></span>
    </div>
    <div class="menu">
    <ul>
                <li class="nav-new">
                  <a class="newa" href="index.php">Главная</a>
                </li>
                <li class="nav-new">
                  <a class="newa" href="#">Запчасти</a>
                </li>
                <li class="nav-new">
                  <a class="newa" href="cars.php">Машины</a>
                </li>
                <li class="nav-new">
                  <a class="newa" href="#">О нас</a>
                </li>
                <li class="nav-new">
                  <a class="newa" href="stamps.php">Марки</a>
                </li>
                <li class="nav-new">
                  <a class="newa" href="location.php">Расположение</a>
                </li>
                <li class="nav-new">
                  <a class="newa" href="prices.php">Цены</a>
                </li>
                
              </ul>
    </div>

    
</html>
<script>
document.querySelector('.burger').addEventListener('click', function(){
document.querySelector('.burger span').classList.toggle('active');
document.querySelector('.menu').classList.toggle("animate");
})
</script>