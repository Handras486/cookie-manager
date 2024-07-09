import { useEffect, useState } from "react";
import "./App.css";
import axios from "axios";

function App() {
  const [cookies, setCookiemanager] = useState<any>([]);

  const token =
    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ3cml0ZXJAZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJXcml0ZXIiLCJleHAiOjE3MjA1NDU0NTMsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDAiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo1MDAwIn0.xzg-k5emOA6a0eSXUovkRnfIyrW6sNdx2AdV9nq30Oc";
  const config = {
    headers: { Authorization: `Bearer ${token}` },
  };

  useEffect(() => {
    axios.get("https://localhost:5000/api/Cookies", config).then((response) => {
      setCookiemanager(response.data);
    });
  }, []);

  return (
    <div>
      <h1>Cookie Manager</h1>
      <ul>
        {cookies.map((cookie: any) => (
          <li key={cookie.id}>
            {cookie.name}
            <br />
            <img src={cookie.cookieImageUrl} alt="" width={500} height={500} />
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;
