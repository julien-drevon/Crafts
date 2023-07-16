FROM composer:latest AS Tests
COPY ./Crafts.Base/ /usr/src/myapp
RUN ls -al
WORKDIR /usr/src/myapp/
RUN  composer install 
RUN  composer tu

FROM composer:latest AS Builder
COPY ./Crafts.Base/ /usr/src/myapp
RUN ls -al
WORKDIR /usr/src/myapp/
RUN rm -rf composer.phar && rm -rf vendor && rm -rf src/tests
RUN  composer install --no-dev


FROM httpd:2.4 AS Final
COPY --from=Builder /usr/src/myapp/src /usr/local/apache2/htdocs/
