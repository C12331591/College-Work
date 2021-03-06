(reset)

(assert (car moving))

(defrule traffic-stop-rule
	(traffic-light red)
	?c <- (car moving)
	=>
	(printout t "Stop car as light has changed to red" crlf)
	(retract ?c)
	(assert (car stopped))
)

(defrule traffic-move-rule
	(traffic-light green)
	?c <- (car stopped)
	=>
	(printout t "Move car as light has changed to green" crlf)
	(retract ?c)
	(assert (car moving))
)