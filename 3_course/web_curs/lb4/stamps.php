<!doctype html>
<html lang="ru">
    <link rel="stylesheet" type="text/css" href="css/main.css">
    <link rel="stylesheet" type="text/css" href="css/stamps.css">
    <?php include 'header.php'; ?>

    <div class="tabs">
        <div class="contents" id="content-1">
            <p>Audi AG — немецкая автомобилестроительная компания в составе концерна Volkswagen Group, специализирующаяся на выпуске автомобилей под маркой Audi. Штаб-квартира расположена в городе Ингольштадт.</p>
            <img src="/img/img17.jpg">
        </div>
        <div class="contents" id="content-2">
            <p>BMW AG — немецкий производитель автомобилей, мотоциклов, двигателей, а также велосипедов. Председателем компании с 2006 по 2015 год был Норберт Райтхофер, с мая 2015 года — Харальд Крюгер, а с 18 июля 2019 года — Оливер Ципсе. Главный дизайнер — Йозеф Кабан.</p>
            <img src="/img/img18.jpg">
        </div>
        <div class="contents" id="content-3">
            <p>Ford — американская автомобилестроительная компания, производитель автомобилей под маркой Ford. Четвёртый в мире производитель автомобилей по объёму выпуска за весь период существования; в настоящее время — третий на рынке США после GM и Toyota, и второй в Европе после Volkswagen. </p>
            <img src="/img/img19.jpg">
        </div>

        <div class="tabs__links">
            <a href="#content-1">Audi</a>
            <a href="#content-2">BMW</a>
            <a href="#content-3">Ford</a>
        </div>
        
    </div>

    <div style="text-align: center;">
        <button class="accordion">Вопрос 1</button>
        <div class="panel">
        <p>Ответ на Вопрос 1...</p>
        </div>

        <button class="accordion">Вопрос 2</button>
        <div class="panel">
        <p>Ответ на Вопрос 2...</p>
        </div>

        <button class="accordion">Вопрос  3</button>
        <div class="panel">
        <p>Ответ на Вопрос 3 ...</p>
        </div>
    </div>


<!-- Trigger/Open The Modal -->
<button class="mybtn" id="myBtn">Открыть модальном окно</button>

<!-- The Modal -->
<div id="myModal" class="modal">

  <!-- Модальное содержание -->
  <div class="modal-content">
    <div class="modal-header">
      <span class="close">&times;</span>
      <h2>Уникальное предложение</h2>
    </div>
    <div class="modal-body" style="text-align: center;">
      <p>Новый спорт кар</p>
      <img style="width: 100%;" src="/img/img19.jpg">
      <p>Скидка 15%</p>
    </div>
    <div class="modal-footer">
      <h3>Спишите купить</h3>
    </div>
  </div>

</div>

<script>
// Get the modal
var modal = document.getElementById("myModal");

// Get the button that opens the modal
var btn = document.getElementById("myBtn");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks the button, open the modal 
btn.onclick = function() {
  modal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function() {
  modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
  if (event.target == modal) {
    modal.style.display = "none";
  }
}






var acc = document.getElementsByClassName("accordion");
var i;

for (i = 0; i < acc.length; i++) {
  acc[i].addEventListener("click", function() {
    this.classList.toggle("active");
    var panel = this.nextElementSibling;
    if (panel.style.maxHeight){
      panel.style.maxHeight = null;
    } else {
      panel.style.maxHeight = panel.scrollHeight + "px";
    } 
  });
}
</script>

</html>