(clear)

(deffunction countGroceries (?grocery-list)
	(bind ?c 0)

	(foreach ?i ?grocery-list
		(+ ?c 1)
	)

	(return ?c)
)

(deffunction maximum (?numbers)
	(bind ?max (nth$ 0 ?numbers))
	
	(foreach ?c ?numbers
		(if (> ?c ?max) then
			(bind ?max ?c)
		)
	)
	
	(return ?max)
)

(deffuntion average (?numbers)
	(bind ?total 0)
	
	(foreach ?c ?numbers
		(+ ?total ?c)
	)
	
	(bind ?result (/ ?total (length$ ?numbers)
	
	(return ?result)
)

(deffunction averageWhile (?numbers)
	(bind ?total 0)
	(bind ?i 0)
	
	(while (< ?i (length$ ?numbers))
		(+ ?total (nth$ i ?numbers))
		(+ ?i 1)
	)
	
	(bind ?result (/ ?total (length$ ?numbers)
	
	(return ?result)
)

(bind ?grocery-list (create$ milk 5.50 butter 4.00 eggs 6.70 bread 2.30 muffins 4.55))

(deffunction totalCost (?grocery-list)
	(if (> (/ (length$ ?grocery-list) 2) 0) then
		(return 0)
	else
		(bind ?i 1)
		(bind ?total 0)
		
		(while (< ?i (length$ ?grocery-list))
			(+ ?total (nth$ ?i ?grocery-list))
			(+ ?i 2)
		)
		
		(return ?total)
	)
)

(deffunction fiveOrMore (?grocery-list)
	(bind ?count 0)
	
	(if (> (/ (length$ ?grocery-list) 2) 0) then
		(return 0)
	else
		(bind ?i 1)
		(bind ?total 0)
		
		(while (< ?i (length$ ?grocery-list))
			(if (>= ?i 5) then
				(+ count 1)
			)
			(+ ?i 2)
		)
		
		(return ?total)
	)
)