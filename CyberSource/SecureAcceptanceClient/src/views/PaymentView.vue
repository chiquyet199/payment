<template>
    <div id="app">
    <form id="payment_confirmation" action="https://testsecureacceptance.cybersource.com/pay" method="post">
      <input type="hidden" name="access_key" v-model="access_key">
      <input type="hidden" name="profile_id" v-model="profile_id">
      <input type="hidden" name="transaction_uuid" v-model="transaction_uuid">
      <input type="hidden" name="signed_field_names" v-model="signed_field_names">
      <input type="hidden" name="unsigned_field_names" v-model="unsigned_field_names">
      <input type="hidden" name="signed_date_time" v-model="signed_date_time">
      <input type="hidden" name="locale" v-model="locale">
      <input name="amount" v-model="amount">
      <input name="currency" v-model="currency">
      <input type="hidden" name="transaction_type" v-model="transaction_type">
      <input type="hidden" name="reference_number" v-model="reference_number">
      <input type="hidden" name="signature" v-model="signature">
      <Button>Pay</Button>
    </form>
    </div>
  </template>
  
  <script lang="ts">
  import { v4 } from "uuid";

  export default {
    data() {
      return {
        access_key: "b0fe96543b3b38ec898bead23a9ff2e4",
        profile_id: "965E3563-E3EE-4C57-8896-C1300819ACA7",
        locale: "en",
        signed_field_names: "access_key,profile_id,transaction_uuid,signed_field_names,unsigned_field_names,signed_date_time,locale,transaction_type,reference_number,amount,currency",
        unsigned_field_names: "",
        transaction_uuid: v4(),
        signed_date_time: "",
        reference_number: "test",
        amount: "100.00",
        currency: "USD",
        transaction_type: "sale",
        signature: ""
      };
    },
    async mounted() {
      const date = new Date();
      date.setSeconds(date.getSeconds(),0);
      this.signed_date_time = date.toISOString().replace(".000Z", "Z");
      let query = `query {
        hmacSha256(message: "access_key=${this.access_key},profile_id=${this.profile_id},transaction_uuid=${this.transaction_uuid},signed_field_names=${this.signed_field_names},unsigned_field_names=${this.unsigned_field_names},signed_date_time=${this.signed_date_time},locale=${this.locale},transaction_type=${this.transaction_type},reference_number=${this.reference_number},amount=${this.amount},currency=${this.currency}")
      }`;
      // API CALL
      try {
        let res = await fetch('http://localhost:5026/graphql/', {
          method: 'POST',
          headers: {
          'content-type': 'application/json',
          },
          body: JSON.stringify({ query }),
        });
        const jsonResponse = await res.json();
        const response = jsonResponse.data.hmacSha256;
        this.signature = response;
      } catch (error) {
        console.log(error);
      }
    },
  };
  </script>