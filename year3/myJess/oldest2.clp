(clear)

(deftemplate person "People in actuarial database"
    (slot age (default -1))
    (slot name )
    (slot gender))
	
(deftemplate oldest-male (slot name) (slot age))

(assert (person (gender Male) (name "Mitt Romney") (age 61) ))
(assert (person (name "Bob Smith") (age 34) (gender Male)))
(assert (person (gender Male) (name "Tom Smith") (age 32) ))
(assert (person (name "Mary Smith") (age 34) (gender Female)))
(assert (person  (name "George Bush") (gender Male)))

(assert (person (gender Female)))

;(assert (oldest-male (age 0)))

(defrule oldest-male-rule
	?o <- (oldest-male (age ?b))
	(person (gender Male) (age ?a&:(> ?a ?b)) (name ?n))
		=>
	(modify ?o (age ?a) (name ?n))
	;student to complete this rule
)    

 
(defrule show-oldest-male
    ?f1 <- (done)
	(oldest-male (name ?x) (age ?y))
	=>
	(printout t "Oldest male is " ?x " aged " ?y  crlf)
    ; complete this rule which fires when other rules has finished.
)    
     
     
(deffunction find-oldest-male ()
    ; student to complete this function
    ; involves asserts, runs and retracts
    (assert (oldest-male (age 0)))
	(run)
	(assert (done))
	(run)
)
    
	