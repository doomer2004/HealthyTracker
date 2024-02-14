import * as yup from 'yup';
import { AddProductFormFields } from '../../models/form/auth/AddProductFormFields';

const addProductFormValidation = yup.object<AddProductFormFields>().shape({
	name: yup.string()
		 .required('Name is required')
		 .min(2, 'Name must be at least 2 characters')
		 .max(50, 'Name must not exceed 50 characters'),
	volume: yup.number()
		 .required('Volume is required')
		 .min(1, 'Name must be at least 1 gr')
		 .max(5000, 'Name must not exceed 5000 gr')
});

export default addProductFormValidation;