import React from "react";
import { useState, useEffect } from "react";
import { register } from '../services/authService';

function Register() {
    const [data, setData] = useState(null);

    // async function registerUser() {
    //     try {
    //       const result = await register();
    //       setData(result);
    //     } catch (error) {
    //       console.error('Error registering user:', error);
    //     }
    //   }

    // useEffect(() => {
    //   registerUser();
    // }, []);

    return (
      <div>
        Hello, let's register
      </div>
    )

    // return (
    //     <div>
    //       {data ? (
    //         <div>
    //           Hello
    //         </div>
    //       ) : (
    //         <p>Loading...</p>
    //       )}
    //     </div>
    //   );
}

export default Register;