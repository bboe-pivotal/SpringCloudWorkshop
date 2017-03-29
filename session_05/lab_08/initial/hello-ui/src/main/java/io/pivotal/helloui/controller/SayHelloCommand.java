package io.pivotal.helloui.controller;

import org.springframework.stereotype.Component;

@Component
public class SayHelloCommand {

    public String sayHello(String toWho) throws Exception {
        try{
            return "I'm just a dumb UI, I don't know how to say hello to " + toWho + "!";
        } catch (Exception e) {
            e.printStackTrace();
            throw e;
        }
    }

}
