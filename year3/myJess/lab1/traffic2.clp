(clear)

(assert (car moving))
(assert (traffic-light green))

(defrule traffic-stop-rule
	(traffic-light red)
	(not (traffic-light green)) ; means fact not in database
	?c <- (car moving)
	=>
	(printout t "Stop car as light has changed to red" crlf)
	(retract ?c)
	(assert (car stopped))
)

(defrule traffic-move-rule
	(traffic-light green)
	(not (traffic-light red))
	?c <- (car stopped)
	=>
	(printout t "Move car as light has changed to green" crlf)
	(retract ?c)
	(assert (car moving))
)