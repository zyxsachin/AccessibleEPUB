var currentCSS = '@import url("visible.css");';
var first = true;

function loadCSS() {
	var mycss;


	for (i=0; i<document.styleSheets.length; i++){
		if (endsWith(document.styleSheets[i].href, "style.css")) 
			mycss=document.styleSheets[i] 
			
	}


	mycss.deleteRule(0);
	mycss.insertRule(currentCSS,0);

}

function storageCSS() {
	if(localStorage){
			if (localStorage.getItem("accessibleEPUBcurrentCSS") !== null) {
			currentCSS = localStorage.getItem("accessibleEPUBcurrentCSS");
		} else {
			localStorage.setItem("accessibleEPUBcurrentCSS", currentCSS);
		}
		currentCSS = localStorage.getItem("accessibleEPUBcurrentCSS");
	}
	else if(sessionStorage){
		if (sessionStorage.getItem("accessibleEPUBcurrentCSS") !== null) {
			currentCSS = sessionStorage.getItem("accessibleEPUBcurrentCSS");
		} else {
			sessionStorage.setItem("accessibleEPUBcurrentCSS", currentCSS);
		}

	}	
	

	loadCSS();
}

function selectVisible() {

	if(localStorage){
		localStorage.setItem("accessibleEPUBcurrentCSS", '@import url("visible.css");');
	}
	if(sessionStorage){

		sessionStorage.setItem("accessibleEPUBcurrentCSS", '@import url("visible.css");');
	}

	currentCSS = '@import url("visible.css");';
	loadCSS();
}

function selectImpaired() {

	if(localStorage){
		localStorage.setItem("accessibleEPUBcurrentCSS", '@import url("impaired.css");');
	}
	if(sessionStorage){

		sessionStorage.setItem("accessibleEPUBcurrentCSS", '@import url("impaired.css");');
	}
	currentCSS = '@import url("impaired.css");';
	loadCSS();
				
}

function selectBlind() {

	if(localStorage){
		localStorage.setItem("accessibleEPUBcurrentCSS", '@import url("blind.css");');
	}
	if(sessionStorage){

		sessionStorage.setItem("accessibleEPUBcurrentCSS", '@import url("blind.css");');
	}
	
	currentCSS = '@import url("blind.css");';
	loadCSS();
				
}

function endsWith(str, suffix) {
    return str.indexOf(suffix, str.length - suffix.length) !== -1;
}