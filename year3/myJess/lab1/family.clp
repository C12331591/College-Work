(clear)

(assert (father john tim))
(assert (brother tim mary))
(assert (father jim john))

(defrule father-rule-1
	(father ?x ?y)
	(brother ?y ?z)
	=>
	(assert (father ?x ?z))
)