package com.crud.crud.Repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.crud.crud.Model.User;

public interface UserRepository extends JpaRepository<User,Long>{


}
