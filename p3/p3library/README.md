# p3library

## Estructura del proyecto
- **p3library**
    - **app**
        - **docs** // Directorio donde se encuentra la documentación de la libreria
            - **[...]** 
        - **lib**   // Directorio donde se almacena la libreria en formato .JAR
            - **mycomponents-1.0.2.jar  
        - **out**
            - **[...]**
        - **src**   // Directorio de el codigo fuente
            - **org**
                - **example**
                    - **App.java**
## Leer la documentación
Para leer la documentación, basta con entrar al directorio _lib_ y abrir el archivo _index.html_, o en la terminal (Y usando MacOS) correr el siguiente comando:
```zsh
open docs/html.index
```

## Compilar y correr
Para compilar y correr el programa se escribe lo siguiente en la terminal
```zsh
javac -d out src/org/example/components/*.java
jar cf lib/{Nombre de la libreria}.jar -C out .
```

