package com.crud.crud.Repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.crud.crud.Model.Product;

public interface ProductRepository extends JpaRepository<Product,Integer> {

}
