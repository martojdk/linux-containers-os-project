package com.linux.containers.controller;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import com.linux.containers.data.model.Person;
import com.linux.containers.data.repository.PersonRepository;


@CrossOrigin(origins = { "http://localhost:3000", "http://localhost:4200" })
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
	
	@GetMapping("/{id}")
    public ResponseEntity<Person> getPerson(@PathVariable int id){
        Optional<Person> p = personRepository.findById(id);
        System.out.println(id);
        if(p == null) {
            return new ResponseEntity<Person>(HttpStatus.NOT_FOUND);
        }
        System.out.println(p.get().getName());
        
        return new ResponseEntity<Person>(p.get(),HttpStatus.OK);
    }
	
	@PutMapping("/{name}")
	public ResponseEntity<Person> savePerson(@PathVariable String name){
		personRepository.save(new Person(name));
		
		return new ResponseEntity<Person>(HttpStatus.OK);
	}
	
	@DeleteMapping("/{id}")
	public ResponseEntity<Person> deletePerson(@PathVariable int id){
	    personRepository.deleteById(id);
		
		return new ResponseEntity<Person>(HttpStatus.OK);
	}
	 @PutMapping("/{name}/{id}")
	  public ResponseEntity<Person> updatePerson(@PathVariable String name, @PathVariable long id,
	      @RequestBody Person person) {
	     this.personRepository.save(person);
	    return new ResponseEntity<Person>(HttpStatus.OK);
	  }
	
}
