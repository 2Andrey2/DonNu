<!doctype html>
<html lang="ru">
    <link rel="stylesheet" type="text/css" href="css/main.css">
    <link rel="stylesheet" type="text/css" href="css/location.css">
    <?php include 'header.php'; ?>


    <form action="" class="ui-form" onsubmit='return validate()'>
    <h3>Войти на сайт</h3>
    <div class="form-row">
    <input type="text" id="email" name='email' required autocomplete="off"><label for="email">Email</label>
    </div>
    <div class="form-row">
    <input type="password" id="password" name='name' required autocomplete="off"><label for="password">Пароль</label>
    </div>
    <p><input type="submit" value="Войти"></p>
    </form>


    <form class="myformemail" name='form' onsubmit='return validate()'>
    <p>Имя:</p> <input type='text' name='name'> <span style='color:red' id='namef'></span><br />
    <p>e-mail:</p> <input type='text' name='email'> <span style='color:red' id='emailf'></span><br />
    <input type='submit' value='Отправить форму'>
    </form>

</html>

<script type='text/javascript'>
function validate(){
   //Считаем значения из полей name и email в переменные x и y
   var x=document.forms['form']['name'].value;
   var y=document.forms['form']['email'].value;
   //Если поле name пустое выведем сообщение и предотвратим отправку формы
   if (x.length==0){
      document.getElementById('namef').innerHTML='*данное поле обязательно для заполнения';
      return false;
   }
   //Если поле email пустое выведем сообщение и предотвратим отправку формы
   if (y.length==0){
      document.getElementById('emailf').innerHTML='*данное поле обязательно для заполнения';
      return false;
   }
   //Проверим содержит ли значение введенное в поле email символы @ и .
   at=y.indexOf("@");
   dot=y.indexOf(".");
   //Если поле не содержит эти символы знач email введен не верно
   if (at<1 || dot <1){
      document.getElementById('emailf').innerHTML='*email введен не верно';
      return false;
   }
}
</script>