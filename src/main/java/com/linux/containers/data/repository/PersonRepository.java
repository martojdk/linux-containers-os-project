package com.linux.containers.data.repository;

import java.util.List;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import com.linux.containers.data.model.Person;

@Repository
public interface PersonRepository extends CrudRepository<Person, Integer>{
	
	Person findByName(String name);
	
	List<Person> findAll();
	
	void deleteByName(String name);

}
