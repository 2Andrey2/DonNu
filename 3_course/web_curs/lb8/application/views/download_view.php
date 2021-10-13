<div>
    <form id="first_form" class="decor" method="POST" action="/Download/downloadFile" enctype="multipart/form-data">
    <div class="form-left-decoration"></div>
    <div class="form-right-decoration"></div>
    <div class="circle"></div>
    <div class="form-inner">
        <h3>Написать нам</h3>
        <input id="nameUser" name="nameUser" type="text" placeholder="Username">
        <input id="emailUser" name="emailUser" type="email" placeholder="Email">
        <textarea name="info" placeholder="Информация..." rows="3"></textarea>
        <div class="inputFile">
            <span style="color: white;">Выберете файл</span>
            <input type="file" name="uploadedFile" />
        </div>
        <input type="submit" name="uploadBtn" value="Загрузить" />
        <?php if(isset($results)){ ?>
            <p><?php echo($results); ?><p>
        <?php } ?>
    </div>
    </form>
<div>

<script>
$(document).ready(function() {
$('#first_form').submit(function(e) {
    var nameUser = $('#nameUser').val();
    var emailUser = $('#emailUser').val();
    $(".error").remove();

    if(nameUser.length<1)
    {
        $('#nameUser').after('<span class="error">Введите имя</span>');
        e.preventDefault();
    }

    if (emailUser.length< 1) {
      $('#emailUser').after('<span class="error">Введите email</span>');
      e.preventDefault();
    } else {
      var regEx = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
      var validEmail = regEx.test(emailUser);
      if (!validEmail) {
        $('#emailUser').after('<span class="error">Не корректный email</span>');
        e.preventDefault();
      }
    }
});
});
</script>