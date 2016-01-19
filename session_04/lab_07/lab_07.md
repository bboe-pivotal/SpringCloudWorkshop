# Lab 7 - Introspection, Monitoring, and Metrics using Spring Boot Actuator

## Set up the Actuator


+ Change to the lab directory:

```
$ cd $COURSE_HOME/session_04/lab_07/initial/hello-spring-boot
```

+ Import the project into your editor/IDE of choice.

+ To `build.gradle` add the following dependency to include the starter for Spring Boot Actuator:

```
compile("org.springframework.boot:spring-boot-starter-actuator")
```

## Introspection Endpoints

+ Build the application:

```
$ ./gradlew build
```

+ Run the application:

```
$ java -jar build/libs/hello-spring-boot-0.0.1-SNAPSHOT.jar
```

+ Try out the following endpoints. The output is omitted here because it can be quite large:

+ http://localhost:8080/beans:: Dumps all of the beans in the Spring context.
+ http://localhost:8080/autoconfig:: Dumps all of the auto-configuration performed as part of application bootstrapping.
+ http://localhost:8080/configprops:: Displays a collated list of all `@ConfigurationProperties`.
+ http://localhost:8080/env:: Dumps the application's shell environment as well as all Java system properties.
+ http://localhost:8080/mappings:: Dumps all URI request mappings and the controller methods to which they are mapped.
+ http://localhost:8080/dump:: Performs a thread dump.
+ http://localhost:8080/trace:: Displays trace information (by default the last few HTTP requests).

## Build and Version Control Info

Spring Boot provides an endpoint (http://localhost:8080/info) that allows the exposure of arbitrary metadata.

One thing that it does well is expose information about the specific build and version control coordinates for a given deployment.

+ Add the following plugin to 'build.gradle'
It will add Git branch and commit coordinates to the `/info` endpoint:

```
buildscript {
    ...
    dependencies {
	...
        classpath("com.homedepot.gitprops:GitPropsPlugin:1.0.8")
    }
}
...
apply plugin: 'com.homedepot.gitprops'

... end of file
project.tasks.jar.dependsOn('gitprops')
```


+ Add the following properties to `src/main/resources/application.yml` ahead of the '---':

```
info:
  build:
  name: ${project.name}
  description: ${project.description}
  version: ${project.version}
```
+ Add the following below the plugin section of 'build.gradle'

```
processResources {
    expand(project.properties)
}
```

These will add the project's properties to the `/info` endpoint. The Spring Boot gradle plugin will cause them to automatically be replaced in the assembled JAR.

+ Build the application:
```
$ ./gradlew build
```

+ Run the application:
```
$ java -jar build/libs/hello-spring-boot-0.0.1-SNAPSHOT.jar
```

+ Visit the application in the browser (http://localhost:8080/info), and verify that the output is similar to the following:

```
{
  build: {
    name: "hello-spring-boot",
    description: "Hello Spring Boot",
    version: "0.0.1-SNAPSHOT"
  },
  git: {
    branch: "master",
    commit: {
      id: "a15f771",
      time: "2015-05-03T16:51:31-0400"
    }
  }
}
```

## Health Indicators

Spring Boot provides an endpoint (http://localhost:8080/health) that allows for the notion of various health indicators.

+ Normally, when Spring Security is not enabled, the `/health` endpoint will only expose an `UP` or `DOWN` value.
To simplify working with the endpoint for this lab, we will turn off its sensitivity.
Add the following to `src/main/resources/application.yml`:

```
endpoints:
  health:
    sensitive: false
```

+ Create the class `io.pivotal.spring.hello.FlappingHealthIndicator` and into it paste the following code:

```
@Component
public class FlappingHealthIndicator implements HealthIndicator{

    private Random random = new Random(System.currentTimeMillis());

    @Override
    public Health health() {
        int result = random.nextInt(100);
        if (result < 50) {
            return Health.down().withDetail("flapper", "failure").withDetail("random", result).build();
        } else {
            return Health.up().withDetail("flapper", "ok").withDetail("random", result).build();
        }
    }
}
```

This demo health indicator will randomize the health check.

+ Build the application:

```
$ ./gradlew build
```

+ Run the application:
```
$ java -jar build/libs/hello-spring-boot-0.0.1-SNAPSHOT.jar
```

+ Visit the application in the browser (http://localhost:8080/health), and verify that the output is similar to the following (and changes randomly!):

```
{
  status: "UP",
  flapping: {
    status: "UP",
    flapper: "ok",
    random: 69
  },
  diskSpace: {
    status: "UP",
    free: 113632186368,
    threshold: 10485760
  }
}
```

## Metrics

Spring Boot provides an endpoint (http://localhost:8080/metrics) that exposes several automatically collected metrics for your application.
It also allows for the creation of custom metrics.

+ Create the class `io.pivotal.spring.hello.GreetingService` and into it paste the following code:

```
@Component
public class GreetingService {

    @Autowired
    CounterService counterService;

    @Value("${greeting}")
    String greeting;

    public String getGreeting() {
        counterService.increment("counter.services.greeting.invoked");
        return greeting;
    }
}
```

This class is using the `@Autowired` `CounterService` to count the number of times that the `getGreeting()` method has been invoked.

+ Refactor the contents of the class `io.spring.hello.HelloSpringBootApplication`:

```
@Autowired
private GreetingService greetingService;

@RequestMapping("/")
public String hello() {
    return String.format("%s World!", greetingService.getGreeting());
}

public static void main(String[] args) {
    SpringApplication.run(HelloSpringBootApplication.class, args);
}
```

`hello()` is now delegating the source of the greeting to our newly created `GreetingService`.

+ Build the application:
```
$ ./gradlew build
```

+ Run the application:
```
$ java -jar build/libs/hello-spring-boot-0.0.1-SNAPSHOT.jar
```

+ Visit the application in the browser (http://localhost:8080) and refresh the page several times.

+ Now visit the `/metrics` endpoint (http://localhost:8080/metrics).
Among the autogenerated metrics you should see a `counter` for the `GreetingService` invocations:

```
counter.services.greeting.invoked: 16,
```

To learn more about the autogenerated metrics, visit http://docs.spring.io/spring-boot/docs/current/reference/html/production-ready-metrics.html.
