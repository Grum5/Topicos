
plugins {
    kotlin("jvm") version "1.9.22"
    application
}

application {
    mainClass.set("com.example.AppKt")
}

dependencies {

    implementation(kotlin("stdlib"))

    val javaFxVersion = "21.0.2"

    implementation("org.openjfx:javafx-controls:$javaFxVersion")
    implementation("org.openjfx:javafx-fxml:$javaFxVersion")
    implementation("org.openjfx:javafx-graphics:$javaFxVersion")

}

repositories {
    mavenCentral()
}

