HOW TO SETUP
1) install composer https://getcomposer.org/download/
2) install XAMPP MySQL Server only
3) install Scoop https://scoop.sh/
4) install Symfony https://symfony.com/download
5) install Heidi https://www.heidisql.com/download.php

in Heidi *MySQL server must be running from now on*
6) new -> with session name 'localhost' -> set user 'root' -> save

in project folder (in terminal)
7) composer install
8) php bin/console importmap:install
9) php bin/console doctrine:database:create
10) php bin/console doctrine:migrations:migrate
11) symfony server:start