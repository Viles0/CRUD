package com.crud.crud.Controller;

import org.springframework.web.bind.annotation.RestController;

import com.crud.crud.Model.Product;
import com.crud.crud.Repository.ProductRepository;

import java.util.List;

import org.springframework.web.bind.annotation.GetMapping;


@RestController
public class ProductController {

    public ProductRepository productRepository;

    @GetMapping("/product")
    public List<Product> geProducts() {
        return productRepository.findAll();
    }
    


}
