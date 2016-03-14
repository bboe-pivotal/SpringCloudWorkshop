package com.example;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@SpringBootApplication
@RestController
public class HelloActuatorApplication {

	@Autowired
	MoodyService moodyService;

	public static void main(String[] args) {
		SpringApplication.run(HelloActuatorApplication.class, args);
	}

	@RequestMapping("/")
	public String hello() {
		return String.format("Hello World! %s", moodyService.getMood());
	}
}