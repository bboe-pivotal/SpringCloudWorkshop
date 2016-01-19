# Cloud Native Application Architectures with Spring and Cloud Foundry

## Student Guide

### Instructor Details

+ Chris DeLashmutt 
+ Advisory Field Engineer - Pivotal 
+ cdelashmutt@pivotal.io

## Prework

1. Ensure you have both git installed on your laptop
    *  [Git](http://git-scm.com/downloads)  

2. Start by downloading the course materials.  
    ```
    $ git clone https://github.com/cdelashmutt-pivotal/SpringCloudWorkshop
    $ cd SpringCloudWorkshop/
    $ git fetch --all
    ```

3. Download needed dependencies
    ```
    cd $COURSE_HOME/session_01/lab_01/spring-music
    ./gradlew assemble
    cd $COURSE_HOME/session_03/lab_05/initial/cities
    ./gradlew assemble
    cd $COURSE_HOME/session_03/lab_06/initial/cities
    ./gradlew assemble
    cd $COURSE_HOME/session_04/lab_07/initial/hello-spring-boot
    ./gradlew assemble
    cd $COURSE_HOME/session_05/lab_08/hello-world
    ./mvnw package
    ```

## Schedule

This is a _loose_ schedule for the day. We will adjust as necessary based on our pace through the material.

The lectures for this class are intentionally very light and are only intended to set the stage for the hands-on labs.
The overwhelming majority of our time will be spent engaging with the technology directly!


## Agenda

+ 9:00 AM - 10:30 AM:: *Session 1:* _Intro to Pivotal Cloud Foundry_
+ 10:30 AM - 11:00 AM:: Morning Break
+ 11:00 AM - 11:30 AM:: *Session 2:* _Custom Buildpacks_
+ 11:30 AM - 12:30 PM:: *Session 3:*  _Spring Data on Cloud Foundry_
+ 12:30 PM - 1:30 PM:: Lunch
+ 1:30 PM - 2:00 PM:: *Session 4:* _Spring Boot Actuator_
+ 2:00 PM - 4:00 PM:: *Session 5:* _Spring Cloud Services on Cloud Foundry_

## Course Materials

* [Session 1](session_01/Session_01.pdf)
  * [Lab 1 - From Zero to Pushing Your First Application](session_01/lab_01/lab_01.adoc)
  * [Lab 2 - Binding to Cloud Foundry Services](session_01/lab_02/lab_02.adoc)
  * [Lab 3 - Scaling Applications](session_01/lab_03/lab_03.adoc)
  * [Lab 4 - Monitoring Applications](session_01/lab_04/lab_04.adoc)
* [Session 2](session_02/Session_02.pdf)
* [Session 3](session_03/session_03.pdf)
  * [Lab 5 - Build a Hypermedia-Driven RESTful Web Service with Spring Data REST](session_03/lab_05/lab_05.adoc)
  * [Lab 6 - Leveraging Spring Cloud Connectors for Service Binding](session_03/lab_06/lab_06.adoc)
* [Session 4](session_04/Session_04.pdf)
  * [Lab 7 - Introspection, Monitoring, and Metrics using Spring Boot Actuator](session_04/lab_07/lab_07.md)
* [Session 5](session_05/Session_05.pdf)
  * Lab 8 - Binding Spring Cloud Services
    * [Lab 8 - With SCS Tile](session_05/lab_08/lab_08.adoc)
    * [Lab 8 - Without SCS Tile](session_05/lab_08/lab_08_no_scs.adoc)
  * Lab 9 - Service Registry
    * [Lab 9 - With SCS Tile](session_05/lab_09/lab_09.adoc)
    * [Lab 9 - Without SCS Tile](session_05/lab_09/lab_09_no_scs.adoc)
  * Lab 10 - Config Server
    * [Lab 10 - With SCS Tile](session_05/lab_10/lab_10.adoc)
    * [Lab 10 - Without SCS Tile](session_05/lab_10/lab_10_no_scs.adoc)
  * Lab 11 - Circuit Breaker Dashboard
    * [Lab 11 - With SCS Tile](session_05/lab_11/lab_11.adoc)
    * [Lab 11 - Without SCS Tile](session_05/lab_11/lab_11_no_scs.adoc)
