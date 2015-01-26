(clear)

(deftemplate advisor (slot feedback) (slot environment) (slot job) (slot stimulus-situation) (slot stimulus-response) (slot medium))

(defrule rule1
	(advisor (environment "papers" | "documents" | "textbooks"))
	=>
	(modify ?*ad* (stimulus-situation verbal))
)

(defrule rule2
	(advisor (environment "pictures" | "illustrations" | "photographs" | "diagrams"))
	=>
	(modify ?*ad* (stimulus-situation visual))
)

(defrule rule3
	(advisor (environment "machines" | "buildings" | "tools"))
	=>
	(modify ?*ad* (stimulus-situation "physical object"))
)

(defrule rule4
	(advisor (environment "numbers" | "formulas" | "computer programs"))
	=>
	(modify ?*ad* (stimulus-situation symbols))
)

(defrule rule5
	(advisor (job "lecturing" | "advising" | "counselling"))
	=>
	(modify ?*ad* (stimulus-response oral))
)

(defrule rule6
	(advisor (job "building" | "repairing" | "troubleshooting"))
	=>
	(modify ?*ad* (stimulus-response hands-on))
)

(defrule rule7
	(advisor (job "writing" | "typing" | "drawing"))
	=>
	(modify ?*ad* (stimulus-response documented))
)

(defrule rule8
	(advisor (job "evaluating" | "reasoning" | "investigating"))
	=>
	(modify ?*ad* (stimulus-response analytical))
)

(defrule rule9
	(advisor (stimulus-situation "physical object") (stimulus-response hands-on) (feedback required))
	=>
	(modify ?*ad* (medium workshop))
)

(defrule rule10
	(advisor (stimulus-situation symbolic) (stimulus-response analytical) (feedback required))
	=>
	(modify ?*ad* (medium "lecture - tutorial"))
)

(defrule rule11
	(advisor (stimulus-situation visual) (stimulus-response documented) (feedback "not required"))
	=>
	(modify ?*ad* (medium videocassette))
)

(defrule rule12
	(advisor (stimulus-situation visual) (stimulus-response oral) (feedback required))
	=>
	(modify ?*ad* (medium "lecture - tutorial"))
)

(defrule rule13
	(advisor (stimulus-situation verbal) (stimulus-response analytical) (feedback required))
	=>
	(modify ?*ad* (medium "lecture - tutorial"))
)

(defrule rule14
	(advisor (stimulus-situation verbal) (stimulus-response oral) (feedback required))
	=>
	(modify ?*ad* (medium "role-play exercises"))
)

;; ******************************
;; Declarations

(import javax.swing.*)
;; Explicit import so we get JFrame.EXIT_ON_CLOSE
(import javax.swing.JFrame) 
(import java.awt.event.ActionListener)
(import java.awt.BorderLayout)
(import java.awt.Color)

;; ******************************
;; DEFGLOBALS

(defglobal ?*f* = 0)
(defglobal ?*c* = 0)
(defglobal ?*en* = 0)
(defglobal ?*jb* = 0)
(defglobal ?*cb* = 0)
(defglobal ?*ad* = 0)

;; ******************************
;; DEFFUNCTIONS

(deffunction create-frame ()
  (bind ?*f* (new JFrame "Media Advisor"))
  (bind ?*c* (?*f* getContentPane)) 
  (set ?*c* background (Color.magenta)))


(deffunction add-widgets ()
	(bind ?environment-list (create$ papers documents textbooks pictures illustrations photographs diagrams machines buildings tools numbers formulas "computer programs"))
	(bind ?job-list (create$ lecturing advising counselling building repairing troubleshooting writing typing drawing evaluating reasoning investigating))
	
	(bind ?*en* (new JComboBox))
	(bind ?*jb* (new JComboBox))
	(bind ?*cb* (new JCheckBox))
	
	(foreach ?cur ?environment-list
		(?*en* addItem ?cur)
	)
	
	(foreach ?cur ?job-list
		(?*jb* addItem ?cur)
	)
	
	(?*c* add (new JLabel "Enter environment and job and specify if feedback is required:") (BorderLayout.PAGE_START))
	(?*c* add ?*cb* (BorderLayout.LINE_END))
	
	(?*c* add ?*en*)
	(?*c* add ?*jb* (BorderLayout.SOUTH))
)

(deffunction add-behaviours ()
	(?*f* setDefaultCloseOperation (JFrame.EXIT_ON_CLOSE))
  
	(?*en* addActionListener (implement ActionListener using
		(lambda (?name ?event)
			;(assert (environment (get ?*en* selectedItem)))
			(modify ?*ad* (environment (get ?*en* selectedItem)))
		)
	))
	
	(?*jb* addActionListener (implement ActionListener using
		(lambda (?name ?event)
			;(assert (job (get ?*jb* selectedItem)))
			(modify ?*ad* (job (get ?*jb* selectedItem)))
		)
	))
	
	(?*cb* addActionListener (implement ActionListener using
		(lambda (?name ?event)
			;(printout t "You pressed the checkbox." crlf)
			
			(if (get ?*cb* selected) then
				;(printout t "It is now selected" crlf)
				(modify ?*ad* (feedback required))
				
			else
				;(printout t "It is now unselected" crlf)
				(modify ?*ad* (feedback "not required"))
			)
		)
	))
)

(deffunction show-frame ()
  ;(?*f* pack)
    (?*f* setSize 400 100)
  (?*f* setVisible TRUE))


;; ******************************
;; Run the program

(defrule init-rule
    (initial-fact)
	?ad <- (advisor)
    =>
	(bind ?*ad* ?ad)
    (create-frame)
    (add-widgets)
    (add-behaviours)
    (show-frame)
)

(reset)
(assert (advisor (feedback "not required") (environment "") (job "")))
(run)