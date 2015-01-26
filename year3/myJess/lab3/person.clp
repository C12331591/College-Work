(clear)

(deftemplate person "People in actuarial database"
    (slot age)
    (slot name)
    (slot gender))


(assert (person (name "Bob Smith") (age 34) (gender Male)))
(assert (person (gender Male) (name "Tom Smith") (age 32) (gender Male)))
(assert (person (name "Mary Smith") (age 34) (gender Female)))
(assert (person (gender Female)))


(defrule male-ages
    (person (name ?n) (age ?a) (gender Male) )
    =>
    (printout t ?n " is " ?a " years old " crlf))

(defrule num-males
	(bind ?n 0)
	
	(person (gender Male))
	=>
	(bind ?n (+ ?n 1))
)

(defrule avg-male-age
	(bind ?sum 0)
	(bind ?n 0)
	
	(person (age ?a) (gender Male))
	=>
	(if ?a then
		(bind ?sum (+ ?sum ?a))
		(bind ?n (+ ?n 1))
	)
	(bind ?avg (/ ?sum ?n))
	(printout t "Average male age is " ?avg " years old " crlf)
)