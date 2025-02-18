HOW TO SETUP
1) install composer https://getcomposer.org/download/
2) install XAMPP MySQL Server only
3) install Scoop https://scoop.sh/
4) install Symfony https://symfony.com/download
5) install Heidi https://www.heidisql.com/download.php

in Heidi *MySQL server must be running from now on*
*might need to change ports if 127.0.0.1:3306 is taken*
6) new -> with session name 'localhost' -> set user 'root' -> save

in project folder (in terminal)
7) composer install
8) php bin/console importmap:install
9) php bin/console doctrine:database:create
10) php bin/console doctrine:migrations:migrate
11) symfony server:start

how to add images:
go into src/Controller/PageController.php
find function gallery()
add new ImageDTO object to array $images