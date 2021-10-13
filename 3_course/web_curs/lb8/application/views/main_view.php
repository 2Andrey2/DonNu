<div id="container">
<div id="heading">
  <h1 class="title">Галерея Васильянов А.И.</h1>
  </div>
  <div id="gallery">
<?php foreach($results as $image) { ?>
    <div class="divimg">
      <a href="/main/full?img=<?php echo($image['id']);?>">
        <img class="img" src="../<?php echo($image['path']); ?>">  
      </a>
    </div>
<?php  } ?>
<div class="clear"></div>
  </div>
<div id="footer">
  </div>
</div>