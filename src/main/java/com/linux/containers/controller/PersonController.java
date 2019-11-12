package com.linux.containers.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RestController;

import com.linux.containers.data.model.Person;
import com.linux.containers.data.repository.PersonRepository;

@RestController
public class PersonController {

	@Autowired
	private PersonRepository personRepository;
	
	@GetMapping("all")
	public ResponseEntity<List<Person>> getAllPersons(){
		List<Person> persons = personRepository.findAll();
		if(persons.isEmpty()) {
			return new ResponseEntity<List<Person>>(HttpStatus.NOT_FOUND);
		}
		
		return new ResponseEntity<List<Person>>(persons,HttpStatus.OK);
	}
	
	@PutMapping("/{name}")
	public ResponseEntity<Person> savePerson(@PathVariable String name){
		personRepository.save(new Person(name));
		
		return new ResponseEntity<Person>(HttpStatus.OK);
	}
	
	@DeleteMapping("/{name}")
	public ResponseEntity<Person> deletePerson(@PathVariable String name){
		personRepository.deleteByName(name);
		
		return new ResponseEntity<Person>(HttpStatus.OK);
	}
	
}
