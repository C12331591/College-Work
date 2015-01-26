(clear)

(assert (initial-fact))

(bind ?environment-list (create$ papers documents textbooks pictures illustrations photographs diagrams machines buildings tools numbers formulas 'computer programs'))
(bind ?job-list (create$ lecturing advising counselling building repairing troubleshooting writing typing drawing evaluating reasoning investigating))

(defrule rule1
	(environment papers | documents | textbooks)
	=>
	(assert (stimulus-situation verbal))
)

(defrule rule2
	(environment pictures | illustrations | photographs | diagrams)
	=>
	(assert (stimulus-situation visual))
)

(defrule rule3
	(environment machines | buildings | tools)
	=>
	(assert (stimulus-situation 'physical object'))
)

(defrule rule4
	(environment numbers | formulas | 'computer programs')
	=>
	(assert (stimulus-situation symbols))
)

(defrule rule5
	(job lecturing | advising | counselling)
	=>
	(assert (stimulus-response oral))
)

(defrule rule6
	(job building | repairing | troubleshooting)
	=>
	(assert (stimulus-response hands-on))
)

(defrule rule7
	(job writing | typing | drawing)
	=>
	(assert (stimulus-response documented))
)

(defrule rule8
	(job evaluating | reasoning | investigating)
	=>
	(assert (stimulus-response analytical))
)

(defrule rule9
	(stimulus-situation 'physical object')
	(stimulus-response hands-on)
	(feedback required)
	=>
	(assert (medium workshop))
)

(defrule rule10
	(stimulus-situation symbolic)
	(stimulus-response analytical)
	(feedback required)
	=>
	(assert (medium 'lecture - tutorial'))
)

(defrule rule11
	(stimulus-situation visual)
	(stimulus-response documented)
	(feedback 'not required')
	=>
	(assert (medium videocassette))
)

(defrule rule12
	(stimulus-situation visual)
	(stimulus-response oral)
	(feedback required)
	=>
	(assert (medium 'lecture - tutorial'))
)

(defrule rule13
	(stimulus-situation verbal)
	(stimulus-response analytical)
	(feedback required)
	=>
	(assert (medium 'lecture - tutorial'))
)

(defrule rule14
	(stimulus-situation verbal)
	(stimulus-response oral)
	(feedback required)
	=>
	(assert (medium 'role-play exercises'))
)

(defrule init-rule
	(initial-fact)
	=>
	(printout t "Input environment type" crlf)
	(bind ?input (read))
	(if (member$ ?input ?environment-list) then
		(bind ?ok 1)
	else
		(bind ?ok 0)
	)
	
	(while (< ?ok 1) do
		(printout t "Not a valid environment type - try again" crlf)
		(bind ?input (read))
		(if (member$ ?input ?environment-list) then
			(bind ?ok 1)
		else
			(bind ?ok 0)
		)
	)
	(assert (environment ?input))
	
	(printout t "Input job type" crlf)
	(bind ?input (read))
	(if (member$ ?input ?job-list) then
		(bind ?ok 1)
	else
		(bind ?ok 0)
	)
	
	(while (< ?ok 1) do
		(printout t "Not a valid job type - try again" crlf)
		(bind ?input (read))
		(if (member$ ?input ?environment-list) then
			(bind ?ok 1)
		else
			(bind ?ok 0)
		)
	)
	(assert (job ?input))
)