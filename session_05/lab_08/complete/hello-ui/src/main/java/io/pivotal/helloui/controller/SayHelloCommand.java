package io.pivotal.helloui.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cloud.client.loadbalancer.LoadBalanced;
import org.springframework.stereotype.Component;
import org.springframework.web.client.RestTemplate;

import com.netflix.hystrix.contrib.javanica.annotation.HystrixCommand;

@Component
public class SayHelloCommand {

	@Autowired
	@LoadBalanced
	RestTemplate restTemplate;

	@HystrixCommand(fallbackMethod = "sayHelloFallback")
    public String sayHello(String toWho) throws Exception {
        try{
        	return restTemplate.getForObject("https://hello-world-server/hello?name={name}", String.class, toWho);
        } catch (Exception e) {
            e.printStackTrace();
            throw e;
        }
    }

	public String sayHelloFallback(String toWho) {
		return String.format("Come back later to hear me say hello, %s", toWho);
	}
}
