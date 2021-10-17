﻿# Books of Eternity

### 1. Запуск и остановка проекта
#### 1.1 Запуск
Перейти в папку **docker**, открываем консоль и вводим команду `docker-compose up -d`

#### 1.2 Остановка

`docker-compose stop`

#### 1.3 Остановка с удалением

`docker-compose down --volumes`

### 2. Обновление структуры БД

В папке **docker/database** изменить скрипт, добавив нужные команды.
Если контейнер с БД уже есть, то нужно его удалить (**п 1.3**)
После выполняем команду в **п. 1.1**