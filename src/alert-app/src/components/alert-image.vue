<template>
    <div>
        <v-container bg fill-height grid-list-md text-xs-center>
            <v-layout row wrap align-center>
                <v-card class="d-flex align-center justify-center" max-width="400px">
                    <div>
                        <v-card-text>
                            <h2 class="text-h6 text-primary">
                                {{ imageData.location }}
                            </h2>
                        </v-card-text>
                    </div>
                    <div>
                        <v-card-text>
                            <span class="text-caption">Location: {{ imageData.location }}</span>
                        </v-card-text>
                        <v-card-title>
                            <span class="text-primary text-subtitle-2">Like count: {{ imageData.likeCount }}</span>
                        </v-card-title>
                    </div>
                    <div>
                        <img :src="imageData.imageMediumUrl" />
                    </div>
                </v-card>
            </v-layout>
        </v-container>
    </div>
</template>
<script setup>
import { defineProps } from "vue";
defineProps(['imageData']);
</script>
<style scoped>
.card {
    width: 4000px;
}
</style>