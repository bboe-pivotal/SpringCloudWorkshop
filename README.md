# Cloud Native Application Architectures with Cloud Foundry

## Student Guide

## Prework

1. Windows or Mac OSX 
2. Java JDK 1.7+ (_Required_, whether or not the .NET labs will be followed)
3. Install the PCF CLI 
    - Download from [here](https://apps.pcf14.cloud.fe.pivotal.io/tools)
4. Firefox or Chrome (Not IE)

## Smoke Test

1. Git clone (or download and unzip from Git) https://github.com/jrolfe-pivotal/SpringCloudWorkshop.git 
2. cd SpringCloudWorkshop/session_04/lab_07/complete/hello-actuator
3. gradlew.bat assemble ( or ./gradlew on MacOSX)
4. java -jar build/libs/hello-actuator-0.0.1-SNAPSHOT.jar
5. browse to http://localhost:8080
6. cf login -a https://api.pcf14.cloud.fe.pivotal.io --skip-ssl-validation (use student1/carn1valc0rp)

### Optional
 
1.  A java IDE is strongly recommended.  Eclipse, STS, or IntelliJ will provide the best experience.
 
2.  Visual Studio, if you plan to try any of the .NET content.
 
3.  ASP.NET 5 - at least one of the labs will be done using ASP.NET 5.  A completed version of this lab will be available/usable for those that don't want to install ASP.NET 5, and just want to review/push the code to Cloud Foundry.

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

