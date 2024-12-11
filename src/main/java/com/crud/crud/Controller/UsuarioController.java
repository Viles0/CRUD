package com.crud.crud.Controller;

import java.util.List;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import com.crud.crud.Model.User;
import com.crud.crud.Repository.UserRepository;


@RestController
public class UsuarioController {

    public UserRepository userRepository;

    @GetMapping("/user")
    public List<User> getusers(){
        return userRepository.findAll();
    }
    

}
