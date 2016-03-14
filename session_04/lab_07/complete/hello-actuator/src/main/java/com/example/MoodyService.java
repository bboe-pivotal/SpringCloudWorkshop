package com.example;

import java.util.Random;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.actuate.metrics.CounterService;
import org.springframework.stereotype.Component;

@Component
public class MoodyService {

	@Autowired
	CounterService counterService;

	public String getMood() {
		counterService.increment("counter.services.moody.invoked");
		return (new Random().nextBoolean() ? "Its a beautiful day" : "I have seen better days");
	}
}
