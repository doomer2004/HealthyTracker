
export const calculateWaterIntake = (weight: number, bodyFatPercentage: number): number => {
	const waterMultiplier = 20; // 1 liter per 20 kg of lean body mass
	const leanBodyMass = weight - (weight * bodyFatPercentage) / 100;
	return Math.ceil(leanBodyMass / waterMultiplier);
 };
 export const calculateFiberIntake = (calories: number): number => {
	const fiberMultiplier = 10; // 10g per 1000 kcal
	return Math.ceil((calories / 1000) * fiberMultiplier);
 };
 
 export const calculateSaltIntake = (weight: number, bodyFatPercentage: number): number => {
	const saltMultiplier = 10; // 1g per 10 kg of lean body mass
	const leanBodyMass = weight - (weight * bodyFatPercentage) / 100;
	return Math.ceil(leanBodyMass / saltMultiplier);
 };
 
 export const calculateCaffeineIntake = (weight: number, maxDosage: boolean): number => {
	const caffeineMultiplier = maxDosage ? 5 : 2.5; // 2.5mg normal, 5mg maximum per 1 kg of total body weight
	return Math.ceil(weight * caffeineMultiplier);
 };

const calculateBMR = (weight: number, height: number, age: number, bodyFatPercentage: number, gender: string): number => {
	const leanBodyMass = weight - (weight * bodyFatPercentage) / 100;
 
	if (gender === 'male') {
	  return 88.362 + 13.397 * leanBodyMass + 4.799 * height - 5.677 * age;
	} else {
	  return 447.593 + 9.247 * leanBodyMass + 3.098 * height - 4.33 * age;
	}
 };
 
 const calculateTEF = (calories: number): number => {
	return 0.1 * calories; 
 };
 
 const calculateAMR = (activityLevel: number): number => {
	if (!isNaN(activityLevel)) {
	  return activityLevel;
	}
	return 1.2; 
 };
 
 const calculateDailyCalories = (weight: number, height: number, age: number, bodyFatPercentage: number, gender: string, activityLevel: number, goal: string): number => {
	const bmr = calculateBMR(weight, height, age, bodyFatPercentage, gender);
	const amr = calculateAMR(activityLevel);
	const tef = calculateTEF(bmr * amr);
 
	switch (goal) {
	  case 'deficit':
		 return bmr * amr + tef - 0.2 * (bmr * amr);
	  case 'maintenance':
		 return bmr * amr + tef;
	  case 'surplus':
		 return bmr * amr + tef + 0.2 * (bmr * amr);
	  default:
		 return 0;
	}
 };
 
 const calculateMacronutrients = (weight: number, height: number, age: number, bodyFatPercentage: number, gender: string, activityLevel: number, goal: string): { protein: number; fat: number; carbohydrates: number } => {
	const leanBodyMass = weight - (weight * bodyFatPercentage) / 100;
 
	let proteinMultiplier: number;
	let fatMultiplier: number;
 
	if (goal === 'deficit') {
	  proteinMultiplier = 2.5;
	  fatMultiplier = 1;
	} else if (goal === 'maintenance') {
	  proteinMultiplier = 1.6;
	  fatMultiplier = 1;
	} else if (goal === 'surplus') {
	  proteinMultiplier = 1.6;
	  fatMultiplier = 1;
	} else {
	  proteinMultiplier = 1.6;
	  fatMultiplier = 1;
	}
 
	const protein = leanBodyMass * proteinMultiplier;
	const fat = leanBodyMass * fatMultiplier;
	const carbohydrates = (calculateDailyCalories(weight, height, age, bodyFatPercentage, gender, activityLevel, goal) - (protein * 4 + fat * 9)) / 4;
 
	return { protein, fat, carbohydrates };
 };
 
 export { calculateBMR, calculateTEF, calculateAMR, calculateDailyCalories, calculateMacronutrients };
 