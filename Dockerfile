FROM maven:3.6.1 AS build
COPY . /usr/src/linuxcontainers/
RUN mvn -f /usr/src/linuxcontainers/pom.xml clean package 

FROM openjdk:8
COPY --from=build /usr/src/linuxcontainers/target/containers-0.0.1-SNAPSHOT.jar /usr/src/linuxcontainers/containers-0.0.1-SNAPSHOT.jar
ENTRYPOINT [ "java","-jar","/usr/src/linuxcontainers/containers-0.0.1-SNAPSHOT.jar"]
