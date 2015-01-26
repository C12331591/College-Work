(clear)

(deftemplate today (slot weather) (slot weatherC) (slot rainfall) (slot rainC) (slot temperature) (slot tempC) (slot sky) (slot skyC))
(deftemplate forecast (slot weather) (slot chance))

(defglobal ?*dr* = 0)
(defglobal ?*rn* = 0)

(defrule rule1
	(today (weather rain))
	?t <- (forecast (weather rain))
	=>
	(modify ?t (chance 0.5))
	(printout t "rule1 activated" crlf)
)

(defrule rule2
	(today (weather dry))
	?t <- (forecast (weather dry))
	=>
	(modify ?t (chance 0.5))
	(printout t "rule2 activated" crlf)
)

(defrule rule3
	(today (weather rain) (weatherC ?w) (rainfall low) (rainC ?r))
	?t <- (forecast (weather dry))
	=>
	(modify ?t (chance (* (min ?w ?r) 0.6)))
	(printout t "rule3 activated" crlf)
)

(defrule rule4
	(today (weather rain) (weatherC ?w) (rainfall low) (rainC ?r) (temperature low) (tempC ?tp))
	?t <- (forecast (weather dry))
	=>
	(modify ?t (chance (* (min ?w ?r ?tp) 0.7)))
	(printout t "rule4 activated" crlf)
)

(defrule rule5
	(today (weather dry) (weatherC ?w) (temperature high) (tempC ?tp))
	?t <- (forecast (weather rain))
	=>
	(modify ?t (chance (* (min ?w ?tp) 0.65)))
	(printout t "rule5 activated" crlf)
)

(defrule rule6
	(today (weather dry) (weatherC ?w) (temperature high) (tempC ?tp) (sky overcast) (skyC ?s))
	?t <- (forecast (weather rain))
	=>
	(modify ?t (chance (* (min ?w ?tp ?s) 0.55)))
	(printout t "rule6 activated" crlf)
)

(deffunction getWeather ()
	(printout t "Input the weather today" crlf)
	(bind ?input (read))
	(if (member$ ?input ?weather-list) then
		(bind ?ok 1)
	else
		(bind ?ok 0)
	)
	
	(while (< ?ok 1) do
		(printout t "Not a valid weather type - try again" crlf)
		(bind ?input (read))
		(if (member$ ?input ?weather-list) then
			(bind ?ok 1)
		else
			(bind ?ok 0)
		)
	)
	(modify ?*td* (weather ?input))
	
	(printout t "Input the level of the weather today (Between 0.0 and 1.0)" crlf)
	(bind ?input (read))
	(if (and (>= ?input 0.0) (<= ?input 1.0)) then
		(bind ?ok 1)
	else
		(bind ?ok 0)
	)
	
	(while (< ?ok 1) do
		(printout t "Not a valid value - try again" crlf)
		(bind ?input (read))
		(if (and (>= ?input 0.0) (<= ?input 1.0)) then
			(bind ?ok 1)
		else
			(bind ?ok 0)
		)
	)
	(modify ?*td* (weatherC ?input))
	
	(printout t "Input the rainfall today (low or high)" crlf)
	(bind ?input (read))
	(if (member$ ?input ?low-high) then
		(bind ?ok 1)
	else
		(bind ?ok 0)
	)
	
	(while (< ?ok 1) do
		(printout t "Not a valid rainfall type - try again" crlf)
		(bind ?input (read))
		(if (member$ ?input ?low-high) then
			(bind ?ok 1)
		else
			(bind ?ok 0)
		)
	)
	(modify ?*td* (rainfall ?input))
	
	(printout t "Input the level of the rainfall today (Between 0.0 and 1.0)" crlf)
	(bind ?input (read))
	(if (and (>= ?input 0.0) (<= ?input 1.0)) then
		(bind ?ok 1)
	else
		(bind ?ok 0)
	)
	
	(while (< ?ok 1) do
		(printout t "Not a valid value - try again" crlf)
		(bind ?input (read))
		(if (and (>= ?input 0.0) (<= ?input 1.0)) then
			(bind ?ok 1)
		else
			(bind ?ok 0)
		)
	)
	(modify ?*td* (rainC ?input))
	
	(printout t "Input the temperature today (low or high)" crlf)
	(bind ?input (read))
	(if (member$ ?input ?low-high) then
		(bind ?ok 1)
	else
		(bind ?ok 0)
	)
	
	(while (< ?ok 1) do
		(printout t "Not a valid temperature type - try again" crlf)
		(bind ?input (read))
		(if (member$ ?input ?low-high) then
			(bind ?ok 1)
		else
			(bind ?ok 0)
		)
	)
	(modify ?*td* (temperature ?input))
	
	(printout t "Input the level of the temperature today (Between 0.0 and 1.0)" crlf)
	(bind ?input (read))
	(if (and (>= ?input 0.0) (<= ?input 1.0)) then
		(bind ?ok 1)
	else
		(bind ?ok 0)
	)
	
	(while (< ?ok 1) do
		(printout t "Not a valid value - try again" crlf)
		(bind ?input (read))
		(if (and (>= ?input 0.0) (<= ?input 1.0)) then
			(bind ?ok 1)
		else
			(bind ?ok 0)
		)
	)
	(modify ?*td* (tempC ?input))
	
	(printout t "Input the sky today" crlf)
	(bind ?input (read))
	(if (member$ ?input ?sky-list) then
		(bind ?ok 1)
	else
		(bind ?ok 0)
	)
	
	(while (< ?ok 1) do
		(printout t "Not a valid sky type - try again" crlf)
		(bind ?input (read))
		(if (member$ ?input ?sky-list) then
			(bind ?ok 1)
		else
			(bind ?ok 0)
		)
	)
	(modify ?*td* (sky ?input))
	
	(printout t "Input the level of the sky today (Between 0.0 and 1.0)" crlf)
	(bind ?input (read))
	(if (and (>= ?input 0.0) (<= ?input 1.0)) then
		(bind ?ok 1)
	else
		(bind ?ok 0)
	)
	
	(while (< ?ok 1) do
		(printout t "Not a valid value - try again" crlf)
		(bind ?input (read))
		(if (and (>= ?input 0.0) (<= ?input 1.0)) then
			(bind ?ok 1)
		else
			(bind ?ok 0)
		)
	)
	(modify ?*td* (skyC ?input))
	
	(facts)
)

(defrule init-rule
	(initial-fact)
	?dr <- (forecast (weather dry))
	?rn <- (forecast (weather rain))
	?td <- (today (weather ""));his prevents an infinite loop
	=>
	(bind ?*dr* ?dr)
	(bind ?*rn* ?rn)
	(bind ?*td* ?td)
	
	(getWeather)
)

(reset)
(bind ?weather-list (create$ dry rain))
(bind ?low-high (create$ low high))
(bind ?sky-list (create$ clear overcast))
(assert (forecast (weather dry) (chance 0.0)))
(assert (forecast (weather rain) (chance 0.0)))
(assert (today (weather "") (rainfall "") (temperature "") (sky "")))
(run)