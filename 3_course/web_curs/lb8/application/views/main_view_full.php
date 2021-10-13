<div>
    <?php foreach($results as $image) { ?>
        <div class="divimg">
        <a href="/main/full?img=<?php echo($image['id']);?>">
            <img class="img" src="../<?php echo($image['path']); ?>">  
        </a>
        </div>
    <?php  } ?>
</div>
<div>
    <?php foreach($results as $image) { ?>
        <dl class="holiday">
        <dt>Название</dt>
            <dd><?php echo($image['Name']); ?></dd>
        <dt>Просмотры</dt>
            <dd><?php echo($image['views']); ?></dd>
        <dt>Информация</dt>
            <dd><?php echo($image['information']); ?></dd>
        <dt>Загрузил</dt>
            <dd><?php echo($image['name'] . " " . $image['email']); ?></dd>
        </dl>
    <?php  } ?>
<div>