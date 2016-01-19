package io.pivotal.helloui.controller;

import com.netflix.hystrix.contrib.javanica.annotation.HystrixCommand;
import io.pivotal.helloui.domain.HelloResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cloud.client.loadbalancer.LoadBalanced;
import org.springframework.stereotype.Component;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.client.RestTemplate;

@Component
public class SayHelloCommand {
    @Autowired
    @LoadBalanced
    RestTemplate restTemplate;


    @HystrixCommand(fallbackMethod = "sayHelloFallback")
    public String sayHello(String toWho) {
        try{
            return restTemplate.getForObject("http://hello-world-server/hello?name={name}", String.class, toWho);
        } catch (Exception e) {
            e.printStackTrace();
            throw e;
        }
    }

    public String sayHelloFallback(String toWho) {
        return String.format("Error, can't say hello to %s", toWho);
    }

}
