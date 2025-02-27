# p3example

## Estructura del proyecto
- **p3example**
    - **app**
        - **lib**   // Directorio de la libreria compilada en formato .JAR
            - **mycomponents-1.0.2.jar***
        - **out**
            - **[...]**
        - **src**   // Directorio de el codigo fuente
            - **org**
                - **example**
                    - **App.java**

## Compilar y correr
Para compilar y correr el programa se escribe lo siguiente en la terminal
```zsh
javac -cp lib/mycomponents-1.0.2.jar -d out src/org/example/App.java
java -cp lib/mycomponents-1.0.2.jar:out org.example.App
```

