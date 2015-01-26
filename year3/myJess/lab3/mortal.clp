(watch all)
(reset)

(assert (man socrates))
(defrule mortality-rule (man ?x) => (assert (mortal ?x)) )

(run)

(facts)